# Dream Journal

#### _Dream Journal, 7/16/2020_

#### By _**Frederick Ernest**_

## Description

_Record users dreams, and find congruent patterns across the world_

## Behaviors

| Spec | Input | Output |
| :-------------      | :------------- | :------------- |
| ** 1. User inputs dream, date, and anything else pertinent to the experience. | "I dreamt I had a pet polar bear, who was biting my arm, on the docks in a bay in thailand, 1/1/2020" | "Well done, recording is the first step to remembering dreams more often!" |
| ** 2. User can search keywords or dates to find dreams that have similiar themes and or on similiar timelines theirs | "Polar bear, 1/1/2020, Portland, OR." | "There were 3 other dreams on 1/1/2020 that included (Polar Bear) as a theme. One in Portland, OR and two in Oslo, Norway." |

## Stretch Goals/ Further exploration
| Spec | Input | Output |
| :-------------      | :------------- | :------------- |
| ** 1. Find paterns in a users dream, show them common themes or keywords" | "Polar Bear" | "You have had 36 dreams about Polar bears" |
| ** 2. " | "Polar Bear" | "You have had 36 dreams about Polar bears" |


## Setup/Installation Requirements

* _Clone or download this repository located at https://github.com/fetonecontrol/DreamJournal.Solution
* _Open in your code editor of choice_
* _Run $ "dotnet restore to download all dev dependencies"_
* _Run $ "dotnet build to build project"_
* _Run $ "dotnet ef database update" to update database_
* _Run $ "dotnet run" to run project_

## API endpoints

* While api is running, the base level endpoint for both Users and Dreams is:

* (https://localhost:5000/api/Dreams)

* (https://localhost:5000/api/Users)

* The following endpoints work for both DB objects interchangibly. Replace User with Dream or vice versa.
Some methods will need to specify somewthing other than "GET" in your API call. They are noted below, along with the key value pairs for posting information.

* Select "raw" and "json" for put and post methods.

| Function | Endpoint | Request Type |
| :------------- | :------------- | :------------ |

| ** Return a list of Dreams or Users. | (https://localhost:5000/api/Dreams) | Get |

| ** Create a Dream or User. | (https://localhost:5000/api/Dreams/Create) | Post | 

| ** Lookup a spesific Dream or User by Id. | (https://localhost:5000/api/Dreams/{int}) | Get | 

| ** Lookup a spesific Dream or User by a complete match in an field related to an object ?Field={query}. | (https://localhost:5000/api/Dreams/?Title={String}) | Get | 

| ** Edit a Dream or User. | (https://localhost:5000/api/Dreams/{int}) | Put |

| ** Delete a Dream or User. | (https://localhost:5000/api/Dreams/{int}) | Delete |

## This project supports pagination through Entity




## Possible keys and values for Dream Fields
* {
*   "dreamId": 3,
*   "date": "0001-01-01T00:00:00",
*   "title": "its a dream",
*   "userName": Frederick,
*   "body": "Once upon a dream, I ate snacks in the park all day"
* }

## Possible values for User Fields
* {
*   "userId": 1,
*   "userName": "Frederick Ernest"
* }

## Known Bugs

_No known bugs_

## Support and contact details

_{Please contact Frederick Ernest for any support issues.}_

## Technologies Used

* _GitHub_
* _C#_

### License

*Copyright (c) 2020 **_Frederick Ernest MIT License_**