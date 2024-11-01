> [!CAUTION]  
> This application is provided as-is and is not supported or endorsed by Renpho or Garmin. It is intended for personal use only and is not to be used for financial gain. The creator takes no responsibility for any consequences that may arise from its use.

```
:::::::..    .,-:::::/   .::::::. 
;;;;``;;;; ,;;-'````'   ;;;`    ` 
 [[[,/[[[' [[[   [[[[[[/'[==/[[[[,
 $$$$$$c   "$$c.    "$$   '''    $
 888b "88bo,`Y8bo,,,o88o 88b    dP
 MMMM   "W"   `'YMUP"YMM  "YMmMY" 
```
# Renpho Garmin Sync (RGS)

Renpho Garmin Sync (RGS) is a command-line interface (CLI) application that synchronizes user body measurements and weight entries from the Renpho app directly to Garmin. By leveraging the internal APIs of both companies, RGS enables seamless data transfer without the need for any intermediary applications. Designed for personal use only, it provides a simple and efficient way to manage health data across platforms.

## Usage
For the simplest use-case (Garmin without Multi-Factor Authentication enabled) it's as simple as running a single command:
```console
rgs sync --gu <GarminUsername> --gpw <GarminPassword> --ru <RenphoUsername> --rpw <RenphoPassword>
```
![Sync exampole](assets/sync.svg)

if you have MFA enabled, you will need to preauthorize your garmin account and pass the MFA code to the application, afterwards you should be able to easily use the `rgs sync` command.
```console
rgs auth garmin --u <GarminUsername> --pw <GarminPassword>
rgs auth garmin --u <GarminUsername> --mfa <MFA Code>
```
![Sync exampole](assets/mfa.svg)

# Commands

### ./rgs sync [options]
##### Description

Sync Renpho body measurements with Garmin.

#### Options

| Option                                                            | Description                                                                                              |
|-------------------------------------------------------------------|----------------------------------------------------------------------------------------------------------|
| `--garminUsername`, `--gu <garminUsername>` (REQUIRED)            | Garmin username/email.                                                                                   |
| `--garminPassword`, `--gpw <garminPassword>`                      | Garmin password.                                                                                         |
| `--renphoUsername`, `--ru <renphoUsername>` (REQUIRED)            | Renpho username/email.                                                                                   |
| `--renphoPassword`, `--rpw <renphoPassword>` (REQUIRED)           | Renpho password.                                                                                         |
| `--renphoProfile`, `--rprofile <renphoProfile>`                   | Renpho profile. [default: None]                                                                          |
| `--dry-run`                                                       | Should only check for new measurements, without actually processing any of the entries. [default: False] |
| `--no-fit-files`                                                  | Should skip saving of the FIT files before sending them to Garmin. [default: False]                      |

---

### ./rgs auth garmin [options]
##### Description

Check and configure Garmin authorization.

##### Options

| Option                                                            | Description                                        |
|-------------------------------------------------------------------|----------------------------------------------------|
| `--u`, `--username <username>` (REQUIRED)                         | Garmin username/email.                             |
| `--password`, `--pw <password>`                                   | Garmin password.                                   |
| `--mfa`, `--mfaCode <mfaCode>`                                    | Multi-Factor Authentication code.                  |

---

### ./rgs auth renpho [options]
##### Description

Check and configure Renpho authorization.

##### Options

| Option                                                            | Description                                        |
|-------------------------------------------------------------------|----------------------------------------------------|
| `--u`, `--username <username>` (REQUIRED)                         | Renpho username/email.                             |
| `--password`, `--pw <password>`                                   | Renpho password.                                   |


# FAQ
## Are the password stored anywhere?
Nope, the only things thare are currently persisted are:
- Garmin authorization tokens (stored encrypted)
- List of already handled measurements from Renpho
- Generated .fit files

## Where is the data stored?
By default the data is stored in default Documents directory, inside a `GarminRenphoSync` subdirectory. This can be modified by editing `config.json` - Set `UseDefaultCachePath` to `false` and provide the new base path in the `CustomCachePath` field

## Does the application automatically detect which measurements were already uploaded to garmin?
Nope, during the initial run the application will try to sync all the measurements that it can find using Renpho API, the result of that will be reused during any subsequent run to upload only newly found measurements.

# Credits
- The Garmin authorization flow is heavily based on the implementation used in [`peleton-to-garmin`](https://github.com/philosowaffle/peloton-to-garmin)
- I've used [`python-garminconnect`](https://github.com/cyberjunky/python-garminconnect) as a reference for Garmin API endpoints and their parameters