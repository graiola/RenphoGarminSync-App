using Dynastream.Fit;
using RenphoGarminSync.Renpho.Shared.Models.Responses;
using System;
using System.IO;

namespace RenphoGarminSync.ConsoleApp
{
    public static class FitGenerator
    {
        public static byte[] GenerateMeasurementFitFile(BodyScaleResponse renphoResponse)
        {
            ArgumentNullException.ThrowIfNull(renphoResponse);
            if (renphoResponse.Weight is null || renphoResponse.Weight <= 0.0f)
                throw new InvalidOperationException("Weight needs to be included in the Renpho Response");

            if (renphoResponse.TimeStamp is null || renphoResponse.TimeStamp <= 0)
                throw new InvalidOperationException("Timestamp needs to be included in the Renpho Response");

            var weightInKg = ConvertToKG(renphoResponse.Weight.Value, renphoResponse.WeightUnit);
            var measurementTime = DateTimeOffset.FromUnixTimeSeconds(renphoResponse.TimeStamp.Value);

            var stream = new MemoryStream();
            var encoder = new Encode(ProtocolVersion.V20);
            encoder.Open(stream);

            var fileIdMesg = new FileIdMesg();
            fileIdMesg.SetType(Dynastream.Fit.File.Weight);
            fileIdMesg.SetManufacturer(Manufacturer.Garmin);
            fileIdMesg.SetGarminProduct(2429); // Garmin Index Scale 2
            fileIdMesg.SetSerialNumber(0x524E5048); // RNPH in HEX
            fileIdMesg.SetTimeCreated(new Dynastream.Fit.DateTime(measurementTime.UtcDateTime));
            encoder.Write(fileIdMesg);

            var weightMesg = new WeightScaleMesg();
            weightMesg.SetTimestamp(new Dynastream.Fit.DateTime(measurementTime.UtcDateTime));
            weightMesg.SetUserProfileIndex(0);
            weightMesg.SetWeight(weightInKg);

            if (renphoResponse.BodyFat.HasValue)
                weightMesg.SetPercentFat(renphoResponse.BodyFat);

            if (renphoResponse.Water.HasValue)
                weightMesg.SetPercentHydration(renphoResponse.Water);

            if (renphoResponse.Muscle.HasValue && renphoResponse.Muscle >= 0.0f)
            {
                //Renpho saves muscle mass as percentage, while garmin uses KGs, we need to adjust the value
                var muscleMass = weightInKg * (renphoResponse.Muscle / 100.0f);
                weightMesg.SetMuscleMass(muscleMass);
            }

            if (renphoResponse.Bone.HasValue)
                weightMesg.SetBoneMass(renphoResponse.Bone);

            if (renphoResponse.BodyAge.HasValue)
                weightMesg.SetMetabolicAge(Convert.ToByte(renphoResponse.BodyAge));

            if (renphoResponse.VisceralFat.HasValue)
                weightMesg.SetVisceralFatRating(Convert.ToByte(renphoResponse.VisceralFat));

            if (renphoResponse.BMR.HasValue)
                weightMesg.SetBasalMet(renphoResponse.BMR);

            if (renphoResponse.BMI.HasValue)
                weightMesg.SetBmi(renphoResponse.BMI);

            encoder.Write(weightMesg);

            encoder.Close();
            return stream.ToArray();
        }

        private static float ConvertToKG(float weight, WeightUnit? unit)
        {
            return unit switch
            {
                WeightUnit.Kg => weight,
                WeightUnit.Lbs => weight / 2.2046f,
                WeightUnit.StoneLbs => weight / 0.15747f,
                WeightUnit.Stone => weight / 0.15747f,
                null => weight,
                _ => weight,
            };
        }
    }
}
