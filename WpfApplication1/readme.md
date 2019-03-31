<h2>Mainpage In WPF</h2>

![alt text](http://i948.photobucket.com/albums/ad330/switch_900/Mainpage_zpsiwlqtbmf.jpg)

<h2>Edit Form</h2>

![alt text](https://i948.photobucket.com/albums/ad330/switch_900/EditFormPage_zps4pc97bpj.jpg)

Download zip from github
Extract files
Open Solution
Remove ASPNetDotCore
Add Existing Project
Navigate to WpfApplicaton1 file
Open WpfApplication1.csproj
Restore Nuget Solutions for entire solution 
Set Startup Project for solution
Multiple startup projects to the following:
IMDbDotNetAPI - Startup
WpfApplication1 - Startup
Open Manage Nuget for entire Solution
Select all updates and run (And accept)
Click yes to all when warning pops up saying Area\HelpPage\View.... already exists
Keep rerunning Nuget Updates until everything is up to date
Update Connections String as per Ann's previous instructions.
Build the Solution

<h3>Test:</h3>
To try and match what I think Ann is doing.  On window load I typed "0000" into the search bar.
I then pressed the search button (magifying glass).
On my computer is takes between 20-30 seconds to load the database on the first search.
Once the first page is loaded you can then hit the next button and again on my computer it takes about 7 seconds to advance
to the next page.

<h3>Notes:</h3>
As I've switched the next button to Synchronous if you hit the next button 10 times quick it will advance the pages one at 
a time (each time taking about 7 seconds to load).  I wouldn't do this during the presentation.

I really do think the Search and associated buttons should be Async.  The buttons can return void but the Search should return Task.  It's too late for me to change it now as I'm on the way to the airport but the line in the Search would say something more like

var titlebasics = await response.Content.ReadAsAsync<IEnumerable<titlebasic>>();

and the buttons should implement a Task.Run() call.  It's to dangerous for me to implement it now because the risk of really messing things up is to much. 

I'm really sorry I couldn't have been here right until the end for this becuase I know we would have been more prepared.  Good luck Wednesday and let me know how it went.

Last minute edit.   I had a few minutes so I added some async capabilities to the mainpage.  I commented out the old working code in case it causes a problem.  Make sure the WebAPI is fully up and running before doing a search or you will get a server error because the connection has to exist to run the UI.

Thanks

Andrew
