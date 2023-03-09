/****** Script for SelectTopNRows command from SSMS  ******/
UPDATE Stage_Covid
SET Country = 'Congo, Rep.'
WHERE Country = 'Congo (Brazzaville)'

UPDATE Stage_Covid
SET Country = 'Congo, Dem. Rep.'
WHERE Country = 'Congo (Kinshasa)'

UPDATE Stage_Covid
SET Country = 'Korea, South'
WHERE Country = 'Czechia'

UPDATE Stage_Covid
SET Country = 'Macedonia'
WHERE Country = 'North Macedonia'

UPDATE Stage_Covid
SET Country = 'Korea, Rep.'
WHERE Country = 'Korea, South'

UPDATE Stage_Covid
SET Country = 'United States'
WHERE Country = 'US'

SELECT DISTINCT(Country)
  FROM [ADIS].[dbo].Stage_Covid
  ORDER BY Country