Alter table Threads
add constraint fk_ForumThread
foreign key (F_Id)
references Forums(F_Id)