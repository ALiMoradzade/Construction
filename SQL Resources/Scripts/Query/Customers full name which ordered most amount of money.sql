--نام و نام خانوادگی مشتری که بیشترین هزینه را کرده است
select [first name], [last name] from [dbo].[Customer]
where [ID] in (

				select [Customer ID] from [dbo].[Order]
				where [Customer ID] = (
										select [Customer ID] from(
																select top 1 [Customer ID],Sum([Total price])as[sum] from [dbo].[Order]
																group by [Customer ID]
																order by[sum] desc
																) t2
										)
				)
