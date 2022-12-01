	
	use amb_Lamp_Shade_Market
	select * from ProductCategories pc
	where 1 = 1 And
	pc.Name LIKE N'%test%' 

select * from ProductCategories select * from ProductCategories pc 
        where 1 = 1
        And pc.Name LIKE N'%test%'


	insert into ProductCategories([Name],[Description],ImageSrc,ImageAlt,ImageTitle,Keywords,MetaDescription,Slug,CreatedDate,UpdateDate,IsRemove)
	values('test1','test1','imgsrc','imgsrc','test1','test1','imgsrc','imgsrc','2022-2-2','2022-2-2',0)