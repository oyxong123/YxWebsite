/*

What I Did:
- Finish setting up LcCategoryListDialog.
- Added image cropper dialog draft. 
- Added blazorize cropper package. 

Excited Achievements:
- Successfully work out the image storing & displaying algorithm. (and the supporting css for framing too)
- Woo!! @o@ I'm starting to experiment with custom css class dyy. 
- 

Website Plans:
- Finish implement blazorize image cropper at image file input like project triangle. 
- Fix when close LcCategory edit dialog through X button, it will throw exception.
- Create a dialog specific to deleting lc category, maybe like after pressing a button a dialog with lists of LC Category will appear. Then from there, we can select whether to edit or delete any of the record. (use MudSimpleTable)
- If deleting LC Category, pop up a confirmation dialog with the mechanism where they need to type "DELETE".
- Fix image aspect ratio in lc dialog. (aspect ratio) (make the size before and after image insertion consistent)
- Start designing and adding Conscioussness Void page. 
- When small screen, display lc in one line like how it's usually documented. If desktop big screen, make picture at left side, and all other details at the right side like instagram desktop.
- Implement LC category selection. (Have another nav menu of sorts at right or left side to show what category the user is viewing, they can switch to other categories at any time)
- Add search feature to search for the record based on record ID in top right side of the page.
- Seems like it's only when the page goes to the splash screen that the nav menu collapses to its header nav item closed. (see if there is a workaround around this, tho it has quite a low priority)

Special Notes:
- The dialogs of Radzen look better. Use Radzen for dialogs. 
- New and edit pages/dialog should reuse the same component/code to reduce duplicated code.
- Resizing image reference: https://www.editorx.com/shaping-design/article/resize-image-css
- Blazor component lifecycle reference: https://blazor-university.com/components/component-lifecycles/ 

Thoughts:
> Some bugs and weird errors can only be found and fixed through running debugging mode.
> 


*/



/*

Development Log:

2023_10_11
- Continued progress in LcCategoryListDialog.
> Wooo, tuple is back in use baby!
> Wait, probably not, I can't.

2023_10_10
- Coded out the refresh code for adding and editing LC Category.
> I don't know why, but seeing how the web app did exactly how I expected it to do makes me slightly 微微一笑.
> That's just a metaphor, I do know the reason why. But the blurry of that reason is the reason why it makes me so happy.

2023_10_09
- Created LC Category edit dialog.

2023_10_08
- Updated service methods of LcService.
- Written code of service methods of ILcCategoryService.
- Implemented Entry().State to accommadate for database disconnected state.
> 噢噢，原来用state.modified over update是为了要accomadate the possibility of disconnected state with database. 原来是如此。

2023_10_07
- Cleaned code.
- Fix some stuff I missed in previous file that I missed.
- Added buttons to add and edit LC Category.
- Halfway created LC Category edit dialog.
- Fixed some previous Lc service mames.

2023_10_04
- Added migration for adding image to LC Category.
- Styled LC Category nav menu for fitting its image. 
- Made LC Category dropdown's text unhighlightable.
> I don't know what else to say seeing this image other than stunning..

2023_10_03
- Fixed bugs and add QoL stuff to LC page.
> It's time to steal code from project triangle again # v#
> I think the website has already become stable enough for me to insert all my records now.

2023_10_02
- Successfully coded out logic for switching LC category in LC page. 
> Understanding this blazr lifecycle is so challenging.

2023_10_01
- Progress set up LC records retrieval based on LcCategory selected.
- Learn about blazor lifecycle.
- Adjust LC page FAB icons.
> Learned about blazor lifecycle which is those oninitializedasync, onparametersetasync, onafterrenderasync, statehaschanged those etc.
> 原来blazor lifecycle有那么深奥的inner workings to understand啊..
> 哦哦哦哦，原来OnParametersSetAsync就是一个会去react那些其他page pass过来的values的method。所以讲如果page已经load了。然后突然有新的parameter value从其他page pass过来，这个method就会自动被叫了。~~~
> Blazor University has the best Blazor Component Lifecycle diagram I ever saw so far.
> 啊啊啊啊，现在明白了blazor component lifecycle过后我才发现，原来我之前在onafterrenderasync里面call statehaschanged是多么多余的method call呀啊~~

2023_09_30
- Styled Login dialog.
- Styled LC Category nav menu.

2023_09_29
- Styled LC Category Nav Menu.
- Modified model and updated database. 

2023_09_28
- Set up display of LC Category details on the right-side nav menu.
> I decided not to use the Alertnotification global method like in Project Triangle. This is because the Snackbar method alone is already quite short. And I have no value to add. So it's a matter of there's no need for me to write another method.
> I think because I technically didn't sleep the entire yesteday night. The drowsiness is sttarting to come and hunt me. 

2023_09_27
- Set up styling of right-side LC Category Nav Menu. 
- Added button to toggle LC Category Nav Menu. 
> Ahhs, so there's a special attribute for MudDrawer that is specifically designed to determine the interaction between it and the MudAppBar.

2023_09_26
- Set up the dropdown of LcCategory selection.
> Huh, how did me and lau usually do with radzen dropdown again?

2023_09_25
- Coded out the secondary nav menu for LC category in LC page.
> HUH. So it IS necessary to put MudDrawer component above anything else within a page.

2023_09_24
- Debugged and fixed login user not detected bug.
- Halfway coded LC Category dropdown selection. 
> Sweet. The texts under language cottage image actually looks pretty good and clean. Just need a slightly bit tweeking only.
> Seems like I need to use aspect ratio property to keep the LC dialog image size consistent.
> Idk why. But looking at this website's data-filled version. Just makes me smile sometimes.

2023_09_23
- Added login service method and cleaned service code. 
- Updated and corrected Login model and dto.
- Set up IsAdmin check in LC page.
> I'm slowly learning all these small code conventions that helps improve the readibility and stucture of my code. Some I learned from forums, some through experience, and some through the teachings and enlightment of others.
> Hmm, what's a time dimension table? Seems like it is to solve the problem of all tables having a datetime stored.

2023_09_22
- Styled LC dialog and added cool comment on host html.
- Halfway set up retrieve login user.
> 原来写在_Host.cshtml file的code全部都会被display出来在webpage inspection view的。

2023_09_21
- Styled LC page and dialog. 
> Bruh, 我就觉得哪里怪怪的。我几时set了一个rz-stack gap:0在LC dialog那边。
> Wait, what. 我才刚跟自己讲一定不是column吧了。到底什么逻辑。
> 太专心了啦，导致我忘记拿了电话把他留在巴士上。幸好巴士司机把他收了起来。还告诉了我要如何去取回。真的非常非常地感谢他。>n <

2023_09_20
- Styled LC page and dialog. 

2023_09_19
- Fixed login nav menu item not collapsing again bug.
- Clean code. 
- Styled LC page. 

2023_09_18
- Finished coded login protected storage flow. 
- Fixed components displayed in sign up dialog
- Made top app bar unclickable when any dialog is opened. (by reducing its z-index to below the dialog wrapper mask's z-index)
- Set temporary LcCategory foreign key in LcDialog.
- Debugged and fixed wrong validator for record ID in new LC record with no record ID input.
> 嗯嗯, proudie. 

2023_09_17
- Halfway debugged audit trails service null reference error.
- Adjusted dialog size of login and sign up.
- Removed the duplicated settings in nav menu. 
- Debugged and fixed audit trails service in login service null reference error. (need to add audit trails service in public constructor)- 
- Halfway coded login protected session storage flow. 
> Hmm, why did I concluded that I can't put the Audit Trails Service in public constructor again..?
> Lol, 原来只是因为我typo.

2023_09_16
- Look up on hosting Blazor Server Web App.
- Added login model and dto mapping.
- Debugged and fixed snackbar displaying full exception message in login dialog.
- Styled login dialog. 
> 难怪我觉得哪里怪怪的，原来是因为要用RadzenTextBox不是RadzenText.

2023_09_15
- Made nav menu close when login button is clicked.
- Debugged and made reopening of login dialog as sign up dialog work.

2023_09_14
- Continued setting up login and sign up flow.

2023_09_13
- Coded out method for login and added audit trails registration for it and sign up.
> Moly, I'm starting to use dynamic to do weird stuff. Is this a sign of gradual movement towards bad code practice.
> Hmm, I think, am I starting to understand what static is?
> Ooooooffh, burnnnn. Why'd you gotta burn yourself ))))

2023_09_12
- Coded in the sign up algorithm.
> Interesting. New iteration of tuple way of using is quite cool.
> Man, refactoring my old function, so its naming and use cases can be broader. Things really came a long way man. 
> Yx Website is really like the baby of LMS and Project Triangle.

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