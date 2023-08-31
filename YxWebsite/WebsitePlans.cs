/*

What I Did:
- Fixed 'LC insert not working as expected' error.
- Reinserted database LC records.
- Updated delete LC record method to decrement all record ID of records with larger record ID by 1.
- 

Excited Achievements:
- Successfully work out the image storing & displaying algorithm. (and the supporting css for framing too)
- Woo!! @o@ I'm starting to experiment with custom css class dyy.
- 

Website Plans:
- Add an insert function. If the specified recordID value has already existed increment all record ID >= to that ID value by one. Validate function.
- Add a delete function. When a record is deleted, decrement all record with record ID > to that ID value by one. 
- Make empty initialization a public method in lc DTO.
- Add "required asterisk" and "required validator" to LC form. Optional for romaji and original text? since sometimes we can only describe what's going on in a pic without text.
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

Special Notes:
- The dialogs of Radzen look better. Use Radzen for dialogs. 
- New and edit pages/dialog should reuse the same component/code to reduce duplicated code.
- 
 
Thoughts:
> 

*/



/*

Development Log:

2023_08_30
- Add delete function in LC. 

2023_08_29
- Debugged and fixed 'cannot convert from IQuery<int> to <int>' error.
- Validated inset on Upload LC Record works.

2023_08_28
- Added insert function code for when LC record is uploaded or edited with a specified Record ID. 
> Man, I didn't know there's something so convenient like this.
> Coding is a time-consuming but rewarding routine.

2023_08_27
- Debugged and fixed RadzenCustomValidator not working bug. (RadzenTemplateForm outer block is required)
- Coded required asterisk to be present on Record ID in Edit LC Upload form.
- Coded validation for Record ID. 
> Pffff=sodhffw, is it that I need to add RadzenTemplateForm outside the RadzenFormField. So RadzenFormField is in the inner code block.
> Man, this took a lot more time than I thought.

2023_08_26
- Validated the best conversion method from string to integer.
- Debugged and fixed decimal error in database. (Manually created migration)
- Coded out where LC Record ID is an optional field. If nothing is filled, it will be saved as a new record. Otherwise, it will be saved and set as the entered record ID.
> It's a bit intriguing how people outside are all discussing on how much they want to move into presoft's inner room.
> This is pretty incredible. Even though both LC upload and edit methods use similar code, they are both serving different functions at different times.

2023_08_24
- Updated database.
- Plan out what other elements need to be considered.

2023_08_23
- Fixed "Picture not appearing in edit form" bug.
- Added optional field to enter record ID. 

2023_08_22
- Clean code.
- Grind. 
> Helped by Lau to fix my code. 

2023_08_21
- Debugged and fixed commentary not storedin database.
- Debugged and fixed edit record uploading as new record.
- Debugged and fixed commentary still not storing bug
> Code 到 sleep.

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