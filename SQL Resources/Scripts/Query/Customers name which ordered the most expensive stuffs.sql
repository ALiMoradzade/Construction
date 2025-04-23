--نام مشتریانی که کالایی با بیشترین قیمت خریده اند؟
select [first name] from [dbo].[Customer]
where [ID] in (
				select [Customer ID] from [dbo].[Order]
				where [ID] in (
								select [Order ID] from [dbo].[Order Detail]
								where [Stuff Name] in (
														select [name] from [dbo].[Stuff]
														where [price] = (
																		select max([Price]) from [dbo].[Stuff]
																		)
														)
								
								)
				)
