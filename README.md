# stilago-eshop
Stilago Eshop task project

Installation guide line

1.  Deploy the database via the database backup.
    The backup file sits under the Stilago.Database folder. The new database should be called stilago.ComputerShop
  
2.  If you are unable to deploy the database via the backup file you can use the scipts provided 
    under the Stilago.Database.
  
    The first script should run on the master database. 
    
    The rest of them should be pointing to the new Stilago.ComputerShop database.

3.  Download the solution package from github and run the visual studio solution from the package.

    Project tasks
    
    Datatabase creation script
        The task 1 DDL script is under Stilago.Database\1.1 CreateDatabase task1.1.sql folder
        The task 1 DML script is under Stilago.Database\1.2 InitialUserAndCountry task 1.2.sql folder
    
        Unfortunatelly I don't have proper scripting tools on my machine so for the DML script I just added the initial              countries and user setup script.
        
        To get more data I added a database backup file under stilago.Database folder. Just restore that database and you            should be ready to go.
        
    Task 2 Copy computer info to another country
        The stored procedure creation script is under Stilago.Database\2.1 Copy comp info to another country Task 2.1.sql            folder
        
        The execution script is under Stilago.Database\2.2 Copy comp execution Task 2.2.sql folder
        
    The visual studio solution
        Just download this whole repository and unpack it.
        After you unpacked all the files just run the solution file and start the project.


