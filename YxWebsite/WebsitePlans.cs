﻿/*

What I Did:
- Add isInitialized variable to check if all data is loaded before page displays data. 
- Write GetLcRecordById method in LC service.
- Set up code for EditLcRecord. 
- Made data reload and page refresh after upload or edit LC. 
- Update GetAllLcRecord from LC service to retrieve data based on ascending order of record ID.
- Debugged and fixed RecordID not stored correctly for new LC record upload.
- 

Excited Achievements:
- Successfully work out the image storing & displaying algorithm. (and the supporting css for framing too)
- Woo!! @o@ I'm starting to experiment with custom css class dyy.
- 

Website Plans:
- Fill in EditLcRecord method from LC service.
- Add "required asterisk" and "required validator" to LC form.
- Add optional field to specify the record ID instead of auto-increment in LC form.
- Figure out the load flow of Lc page. (https://www.editorx.com/shaping-design/article/resize-image-css)
- Adjust lc record mudcards.
- Make app bar become Elevation="1" when a dialog is open, other times just make it Elevation="0".
- Save the state of previously expanded drawer after clicking into any link (Or can just highlight the current page link when open the menu) (NavMenu).
- Contract other nav groups when a new nav group is opened. (NavMenu)
- Add audit trails model and create audit trail straight from service.
- Set border size based on LC image in LcDialog. Later on should be uploading images in 16:9.
- Add a login function so that if it is me that has logged in, I can utilize the add post delete post etc function.
- Resize image of Lc upload properly. (https://www.w3docs.com/snippets/css/how-to-auto-resize-an-image-to-fit-an-html-container.html)
- 

Special Notes:
- The dialogs of Radzen look better. Use Radzen for dialogs. 
- New and edit pages/dialog should reuse the same component/code to reduce duplicated code.
- 
 
Thoughts:
- Learned how to get context arguments from razor to c# for passing temporary context variables.
- Finally understand how passing arguments to Radzen dialog works.
- I finally encountered it! The situation where adding ++ before variable is the correct way to achieve the functionality I want!
- 

 */


/*

Development Log:

2023_08_19
- 

2023_08_18
- Added new properties to LC model. 
- Set up lc record mudcards.
- Updated database.
- Updated LC service to account for record ID. 

*/