/*

What I Did:
- 

Excited Achievements:
- Successfully work out the image storing & displaying algorithm. (and the supporting css for framing too)
- Woo!! @o@ I'm starting to experiment with custom css class dyy. 
- 

Website Plans:
- Add a login function so that if it is me that has logged in, I can utilize the add post delete post etc function.
- Seems like it's only when the page goes to the splash screen that the nav menu collapses to its header nav item closed. (see if there is a workaround around this, tho it has quite a low priority)
- Fill validator stringin LC dialog. 
- Create sign up page. 
- When small screen, display lc in one line like how it's usually documented. If desktop big screen, make picture at left side, and all other details at the right side like instagram desktop.
- Implement LC category selection. (Have another nav menu of sorts at right or left side to show what category the user is viewing, they can switch to other categories at any time)
- Add search feature to search for the record based on record ID in top right side of the page.

Special Notes:
- The dialogs of Radzen look better. Use Radzen for dialogs. 
- New and edit pages/dialog should reuse the same component/code to reduce duplicated code.
- Resizing image reference: https://www.editorx.com/shaping-design/article/resize-image-css
 
Thoughts:
> Interesting. New iteration of tuple way of using is quite cool.
> Man, refactoring my old function, so its naming and use cases can be broader. Things really came a long way man. 
> Yx Website is really like the baby of LMS and Project Triangle.
> 

*/



/*

Development Log:

2023_09_11
- Changed name of "hash" in login model into "salt".
- Progress build login/sign up algorithm.
> Tried examining code through github mobile for the 1st time! This is pretty interesting.
> Mannn, the font colors and font of github mobile is SO GOOOOD.
> Uwaaaah, this code is so badd mannnn who wrote this code.
> Omaigoddd 不忍直视哇啊啊啊
> Puuuuuuuuuuuuu.... did I really just hash my password on client page (arr g hhh ghh ahh_
> ..this is pain.
> The more I learn, the more painful looking at my old code is.

2023_09_10
- Refine custom nav menu code.
- Added ability to pass Action delegate to custom nav menu. 
- Added auto initialization for login dto.
> Man, this original coder's implementation of custom nav menu is genius man!
> aHHHHHH, I actually implemented it. 
> fdsiaoivnclnk, IT'S A SUCCESS!!!
> MMMM, I'm able to understand what is going on behind the error visual stusio is showing immediately even though it's not explicitly stated.
> Ohh, the reason the login dialog received object null reference is because no loginForm was initialized yet. 

2023_09_09
- Implemented custom nav menu.
> Owhh, so attributes are actually just parameters of the component code file.
> This random person's custom nav menu component design is really genius.
> I'm starting to feel a bit gandong that I am now learning how to build custom components already.
> When using a web app, I never realized just how much knowledge goes into retrieving and modifying all the values of a form/record.

2023_09_08
- Drawn Yx Website EERD. 

2023_09_07
- Updated database. 
- Created login service and updated login dialog. (not done)

2023_09_06
- Created login model, dto, and dialog. (not done)
> Me creating this website plan file is one of the most correct decesion I made to my project.
> Weird realization, but I think I might not like to talk more than I thought I am.

2023_09_05
- Created audit trails model, service, dto, and update context.
- Added migration and updated database.
- Added audit trail calls to LC service.

2023_09_04
- Created LcCategory and updated database.
- Checked that nav menu selection is stayed on previous selection. 
> Mann, the API and attribute options in Mud Components are good man. 
> Now that I finally know how to read documentation, and have read so much documentation including from Radzen and other sources. Man, MudBlazor documentation is so reader friendly man.

2023_09_03
- Styled LC page to rescale images automatically and did some small UI tweaks.
- Updated models. 
> Ahhh, now I get what bootstrap css documentation is trying to say with their shorthand css names.
> Seems like bootstrap css uses SASS too.
> oOoOoooOoOO, sir you just hit gold.
> In an ideal world, I would hope everyone learns programming. This feels like idk, such another side of the world.

2023_09_02
- Set border size as 16:9 in LC edit dialog
- Experimented with elevation.

2023_09_01
- Adjusted LC MudCards to display basic record details. 
- Changed insert function code in upload, edit, and delete LC methods back to ExecuteUpdateAsync EF Core Expression.
- Made LC Dto an empty initialization.
- Deleted code that initializes empty fields.
> using ctrl+c then ctrl+v without highlighting text first copy and postes the whole line by default in VS, which is so pretty useful.
> Ahhhs, so the reason it didn't worked before this is because I didn't add "SetsRequiredMembers" above my constructor to auto set the required properties.

2023_08_31
- Fixed 'LC insert not working as expected' error.
- Reinserted database LC records.
- Updated delete LC record method to decrement all record ID of records with larger record ID by 1.
- Added confirmation dialog before deleting LC record.
- Validated insert function code in upload and edit dialog is working. 
- Updated LC edit dialog fields.
> omaigosh, lmaoo, don't tell me the reason '.ExecuteUpdateAsync' didn't work before is because I incremented the records in between the new insert record ID and old record ID. Thus causing all of them to increment back to the same number due to simple math and sequence logic. SoI might not have needed to change the function actually. Ahhhh. Hey, should I change it back during the next session?

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