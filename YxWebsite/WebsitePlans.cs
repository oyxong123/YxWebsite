/*

What I Did:
- Debugged and fixed commentary not storedin database.
- Debugged and fixed edit record uploading as new record.
- 

Excited Achievements:
- Successfully work out the image storing & displaying algorithm. (and the supporting css for framing too)
- Woo!! @o@ I'm starting to experiment with custom css class dyy.
- 

Website Plans:
- Fix "Commentary not showing in Language Cottage MudCards" bug.
- Fix "Picture not appearing in edit form" bug.
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
- When small screen, display lc in one line like how it's usually documented. If desktop big screen, make picture at left side, and all other details at the right side like instagram desktop.
- 

Special Notes:
- The dialogs of Radzen look better. Use Radzen for dialogs. 
- New and edit pages/dialog should reuse the same component/code to reduce duplicated code.
- 
 
Thoughts:
~ 

*/



/*

Development Log:

2023_08_21
- 

2023_08_20
- Made data reload and page refresh after upload or edit LC. 
- Update GetAllLcRecord from LC service to retrieve data based on ascending order of record ID.
- Debugged and fixed RecordID not stored correctly for new LC record upload.
- Updated code in EditLcRecord method of LC service.
- Updated UploadLcRecord of LC service to return the updated LcDto.
- Checked if the the returned lcDto from UploadLcRecord of LC service has the updated increamented record ID.
> Finally understand how passing arguments to Radzen dialog works.
> I finally encountered it! The situation where adding ++ before variable is the correct way to achieve the functionality I want!
> That's a bunch of code I vomitted out.

2023_08_19
- Add isInitialized variable to check if all data is loaded before page displays data. 
- Write GetLcRecordById method in LC service.
- Set up code for EditLcRecord. 
> Learned how to get context arguments from razor to c# for passing temporary context variables.

2023_08_18
- Added new properties to LC model. 
- Set up lc record mudcards.
- Updated database.
- Updated LC service to account for record ID. 

*/