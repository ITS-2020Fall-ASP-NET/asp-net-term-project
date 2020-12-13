# ITS2020Fall-ASP.NET Team Project
[Confluence Page](https://1souljo.atlassian.net/wiki/spaces/ITS2020FAL/pages/225312769/Second-hand+market+with+advanced+features)

# Description
Community based Kijiji-like second-hand market service.  
Focus on ‘nearby’ oriented service to give users a more neighboring and secured feel.  
So it should support a more specific address-based search.  
Kijiji’s minimum address unit is ‘City’ (i.e. Toronto, Mississauga, Oakville), but we can support the search where users can set the current location and find the result from the closest.  
In addition to it, add some useful features to provide users with better transaction experience.

# Development environment
* ASP.NET MVC
* Entity Framework 6

# How to run
1. Open ITS2020_ASPNET_Team_Prj.sln file in Visual Studio
2. Run
3. Open localhost:44392 in your browser
4. (Optional) Set database connection if necessary
```
  <connectionStrings>
    <add name="NeighTradeContext" connectionString="Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=NeighTrade;Integrated Security=SSPI;" providerName="System.Data.SqlClient" />
  </connectionStrings>
```
5. Pre-defined user information
    * id : hansol.jo@gmail.com, password : 12341234
    * id : sarachen0712@gmail.com, password : 12341234


# Features
Name | Desc. | Tier  | Assignee | Status
-----|------|:-----:|:---------:|:-------|
Main Page | includes a search box (search by address / item name) | 2 | Hansol Jo | Done
Item list | Items on sale<br>From the ‘popular items’ menu or search | 3 | Hansol | Done
Item detail | Detailed information about selling items | 2 | Sara Chen | Done
Post ad | Users should input the detailed item information<br>Picture upload | 2 | Hansol Jo | Done
My Account | User account page | 1 | Hansol Jo | Done
Sign in / up | Input validation<br>Address form | 1 | Hansol | Done
Manage My Ads | List of my current / post ad histories | 1 | Sara Chen | Done
My Likes | List of items that I expressed the interest | 1 | Sara Chen | Done
My Orders | List of the current user’s previous orders<br>Calendar view for delivery date picking | 3 | Sara Chen | Done
