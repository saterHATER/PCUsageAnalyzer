I'12/01/14:	Ok, I don't quite have a clear vision of what I'm doing, so I'll just move on an 
			initiative I had of turning all of those string dates into datetimes.
12/07/14:	I've done enough troubleshooting to figure out the problem: processes don't go 
			over to xml files very well. I'll need to convert processes to strings/datetimes
			as I go.(Or come up with a better solution for file writing) Yippee!
12/08/14:	I've taken care of the issue of sampling again, now what's left is the dreadful 
			task of fixing the matching equation again. Yuch!
			A seriouse problem arrises: Do I log a process from its epoch? (this doesn't include
			shutdown time) I say yes!
			I've finished the task of including all important atributes of a system.process to my
			DT. Now I'm moving on to the terrifying task of replacing the addition mechanism I 
			currently have. Ouch...hmm, well. That wasn't so bad. Lets take a break, shall we?
12/09/14:	I realized I only need 1 datastructure for point deductions and bonuses. I'll have 
			to write out my idea for a deduction calculator outfit quickly before the whole idea
			take a 180...Oh crap, I ran in to a brain twister. I might've fixed it...Nope, still
			Getting thrown for loops.
12/10/14:	Struggling to get my new proposal off the ground. Man, I need a whiteboard. but
			I think I've got it now. D'OH! the current datastructure doesn't account for various
			programs...But I have an idea...
12/11/14:	I spend most of today weeding out a problem with depreciating the old string-formatted
			program start times. Now I'm onto implementing my new datastructure! but before that, 
			I need to take a serious invintory of my spec-vals in the DT. Spec values sorted a bit.
			I added a dictionary of my new Data structure. So yeah, step 1.
			New problem: Can I save Extended properties in XML???????
12/13/14:	EVERY TIME I come back to this I wre-write everything! hot-damn! this is hard.
			So what I'm doning now is ding a datatable. It's got 8 columns, 1 for the procname,
			7 for the days. each entry is going to have a dataset for the times and value. I'm 
			putting that all together now... But I'm going to need internet access. Jesus, I can't 
			do this when I don't trust the wifi. Damn.
12/14/14:	I'm sticking with the current schema of making a new DT for penalties. So far so good.
			I'll need to work on returning a value for the penalty for a specific program...done!
			Allright, lets address the issue of the _index of DT's being lost. if it's no
			problem, then move on to adding the Penalties DT to the CPmanager for testing.
			Turns out, I'm not using the _index in the same way, I'll just have to use the
			HasRow function. A minor problem is that I didn't add a row# column. Drats.'
			Allright, I need to integrate/test the new DT, I'm neverous :(
			I've cleaned up the classes a bit, so I'll get to testing shortly, wish me luck.
12/15/14:	So...yeah, testing...It went as horribly as I expected. no matter. I'll see if I 
			can't Serialize A list of ints/doubles, because that may work as well. Nope, this 
			is pretty bad. I'll have to save my data some other way or find a new file-writer
			(going with the latter)...Too hard, I'll write all my stupid data to a supid
			string :< 
			It's working now, I have to find the bug that keeps it from detecting identical lines'
12/16/14	Fixed the issue, now It's on to testing the UP function and eventually the RP thing
			I've testing everything and it looks fine. Now i'm on to implementing more advanced
			instances. BTW: datetime.timeofday.totalminutes is a double...huh.
12/17/14	Aight, I successfully tested the calculatin portion of the penalties. ALl good. 
			Now I think I have to move to the task of adding a gui. Oh god, please help me 
12/20/14	I've started on the form design and I allready want to re-do everything. Figures. 
			Currently I'm looking to make this a multi-user multi-program editor. As opposed 
			to the single user, single program thing. Dern, biotches!
12/21/14	Today I'll work on integrating this thing into the DS manager so that It can
			fetch and send the appropriate data without having to expand my knowledge of
			OOP any further :(. So, I'm trying to figure out how to populate the drop-down
			box when the users are selected, but I'm hopelessly confused. Ok, so here's my
			game-plan. I'm going to create the form instance in the beginning and pass it 
			the dataset...that, or inherit methods from the DS manager (here's to 2 weeks
			trying to straiten this out...). I figured out how to add programs to the list 
			upon selecting the user. Now onto the part of adding new panalties.
12/22/14	Gahh! I can't think of a good way to do this! I'll have to do some sloppy mess of
			copying code from one class to another! boo! No I won't. I'll only have to inherit
			the base class and call a get-function on the present DT...I think...So I'll have
			to make a method to write to a DT, but it'll take the DT as an arg (needs 2!) This
			is super complex! Allright, I need to reorganize my datastructures. This is gonna 
			be tricky.
12/25/14	Aww, fuck I broke the program. Hopefully I can fix it...actually, it was a message I 
			put in there a while ago, so, hopefully everything works....My problem now is that
			the inherited method is 'stealing' the DT from the DSmanager. I need to somehow
			re-model the Pmanager's method. I fixed the dt theft (needs validation), but I didn't 
			fix the problem. Looks like I've got working code. I need to find out how to launch
			the form correctly.
			I broke the repo on my home machine. So this is a test edit.