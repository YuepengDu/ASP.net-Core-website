# Group10_A2
Yuepeng Du (s3698728)
Qucheng Zhang (s3713572)

Trello link for our group : https://trello.com/b/YlZMAZpV/group10a2

Project description
Our project is made for a bank for both kinds of users (admin & customer), it starts off with a home page can direct to login page for both users and a privacy page as well. If login as a customer, you would be able to check your balance and make deposit & withdraw, transfer to a different account, checking transactions. Moreover you can also set up scheduled bills. Certainly you as the owner of the account, you can modify & delete the bills.
For an admin, you can login via the (login as admin) link in the login page to view the dashboard of all customers. You may lock the user for 1 minute, check transactions with filtered date if you like, block/unblock bills. Basiclly, an admin have the full full access for manager accounts excepts change the amount of money in those accounts. (Admin can not steal customers' money). All details are stored in a database, the program can communicate with the database via an API.

The record type is found in Areas/Admin/Models and Areas/Customer/Models, all models are used as for EF-Core. The code using the record can be found in Areas/Admin/Controllers and Areas/Customer/Controllers. Those names are equivalent with the model such as for Customer.cs, the controller would be CustomerController.cs. The usage of records are not likely to be 100% coverd, but mostly it included update,read & write and delete for some models, as login details are not deleteable. As thoes Records being immutable classes, they are powerful performance feature. The reason to implement these immutable classes is often for maximum performance and also for preventing bugs and even there are bugs, they are easier to be tracked. 

Web CSS style reference: NAB Bank

In the registration page, we tried to complete the identity API in the HD part, but due to time reasons, we could not fully implement it and we have left a alert there.
