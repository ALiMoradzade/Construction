--نام مشتریانی که بیشتر از 2 سفارش داشته اند؟
select [first name] from [dbo].[Customer]
where [ID] in (
				select [Customer ID] from [dbo].[Order]
				group by [Customer ID]
				having count([Customer ID]) > 2
				)
