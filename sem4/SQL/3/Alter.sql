use Быков_3
ALTER TABLE ТОВАРЫ ADD Дата_поступления date;

ALTER TABLE ТОВАРЫ ADD POL nchar(1) default 'м' check (POL in('м','ж'));

ALTER TABLE ТОВАРЫ DROP Column Дата_поступления

--DROP table ТОВАРЫ