use amb_Lamp_Shade_Market


select * from ProductCategories pc
        where 1 = 1
        And pc.Name   LIKE '%test%'
        
use amb_Lamp_Shade_Market
--exec sp_executesql N'select * from ProductCategories pc 
--        where 1 = 1
--        And pc.Name   LIKE ''%''@name''%'''
--         N'@name varchar(50)', @name=@name
----',N'@Name nvarchar(5)',@Name=test1