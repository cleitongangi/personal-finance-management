
CREATE TABLE public.app_language (
	id int2 NOT NULL,		
	description varchar(255) NOT NULL,	
	is_default boolean NOT NULL,
	CONSTRAINT app_language_pk PRIMARY KEY (id)
);
insert into app_language values(1,'English',true);
insert into app_language values(2,'Portuguese',false);

CREATE TABLE public.entry_type (
	id int2 NOT NULL,		
	description varchar(255) NOT NULL,
	CONSTRAINT entry_type_pk PRIMARY KEY (id)
);
insert into entry_type values(1,'Incoming');
insert into entry_type values(2,'Expense');

CREATE TABLE public.template_entry_category (
	id int4 NOT NULL,
	app_language_id int2 NOT NULL,
	entry_type_id int2 NOT NULL,
	description varchar(255) NOT NULL,
	created timestamp with time zone NOT NULL,
	updated timestamp with time zone NOT NULL,,
	active boolean NOT NULL,
	CONSTRAINT template_entry_category_pk PRIMARY KEY (id),
	CONSTRAINT template_entry_category_fk_app_language FOREIGN KEY (app_language_id) REFERENCES public.app_language(id),
	CONSTRAINT template_entry_category_fk_entry_type FOREIGN KEY (entry_type_id) REFERENCES public.entry_type(id)	
);

CREATE TABLE public.template_entry_subcategory (
	id int4 NOT NULL,
	app_language_id int2 NOT NULL,
	category_id int4 NOT NULL,
	description varchar(255) NOT NULL,
	created timestamp with time zone NOT NULL,,
	updated timestamp with time zone NOT NULL,,
	active boolean NOT NULL,
	CONSTRAINT template_entry_subcategory_pk PRIMARY KEY (id),
	CONSTRAINT template_entry_subcategory_fk_app_language FOREIGN KEY (app_language_id) REFERENCES public.app_language(id),
	CONSTRAINT template_entry_subcategory_fk_category FOREIGN KEY (category_id) REFERENCES public.template_entry_category(id)	
);

--# English
--Incomings
insert into template_entry_category values(1,1,1,'Fixed Incomings',now(),now(),true);
insert into template_entry_category values(2,1,1,'Variable Incomings',now(),now(),true);
--Expenses
insert into template_entry_category values(3,1,2,'Housing',now(),now(),true);
insert into template_entry_category values(4,1,2,'Health',now(),now(),true);
insert into template_entry_category values(5,1,2,'Transportation',now(),now(),true);
insert into template_entry_category values(6,1,2,'Personal',now(),now(),true);
insert into template_entry_category values(7,1,2,'Education',now(),now(),true);
insert into template_entry_category values(8,1,2,'Leisure',now(),now(),true);
insert into template_entry_category values(9,1,2,'Others',now(),now(),true);

--# Portuguese
--Incomings
insert into template_entry_category values(10,2,1,'Receitas Fixas',now(),now(),true);
insert into template_entry_category values(11,2,1,'Receitas Variáveis',now(),now(),true);
--Expenses
insert into template_entry_category values(12,2,2,'Habitação',now(),now(),true);
insert into template_entry_category values(13,2,2,'Saúde',now(),now(),true);
insert into template_entry_category values(14,2,2,'Transporte',now(),now(),true);
insert into template_entry_category values(15,2,2,'Pessoais',now(),now(),true);
insert into template_entry_category values(16,2,2,'Educação',now(),now(),true);
insert into template_entry_category values(17,2,2,'Lazer',now(),now(),true);
insert into template_entry_category values(18,2,2,'Outras',now(),now(),true);

select * from template_entry_category

CREATE TABLE public."user" (
	id int8 NOT NULL GENERATED ALWAYS AS IDENTITY( INCREMENT BY 1 MINVALUE 1 MAXVALUE 9223372036854775807 START 1 CACHE 1 NO CYCLE),
	"name" varchar(255) NOT NULL,
	user_name varchar(255) NOT NULL,
	"password" varchar(255) NOT NULL,
	email varchar(255) NOT NULL,
	created timestamp with time zone NOT NULL,,
	updated timestamp with time zone NOT NULL,,
	active bool NOT NULL,
	CONSTRAINT user_pk PRIMARY KEY (id)
);

CREATE TABLE public.entry_category (
	id int8 NOT NULL GENERATED ALWAYS AS IDENTITY( INCREMENT BY 1 MINVALUE 1 MAXVALUE 9223372036854775807 START 1 CACHE 1 NO CYCLE),
	user_id int8 NOT NULL,
	entry_type_id int2 NOT NULL,
	description varchar(255) NOT NULL,
	created timestamp with time zone NOT NULL,,
	updated timestamp with time zone NOT NULL,,
	active boolean NOT NULL,
	CONSTRAINT entry_category_pk PRIMARY KEY (id),
	CONSTRAINT entry_category_fk_user FOREIGN KEY (user_id) REFERENCES public.user(id),
	CONSTRAINT entry_category_fk_entry_type FOREIGN KEY (entry_type_id) REFERENCES public.entry_type(id)	
);

CREATE TABLE public.entry_subcategory (
	id int8 NOT NULL GENERATED ALWAYS AS IDENTITY( INCREMENT BY 1 MINVALUE 1 MAXVALUE 9223372036854775807 START 1 CACHE 1 NO CYCLE),
	user_id int8 NOT NULL,
	category_id int8 NOT NULL,
	description varchar(255) NOT NULL,
	created timestamp with time zone NOT NULL,,
	updated timestamp with time zone NOT NULL,,
	active boolean NOT NULL,
	CONSTRAINT entry_subcategory_pk PRIMARY KEY (id),
	CONSTRAINT entry_subcategory_fk_user FOREIGN KEY (user_id) REFERENCES public.user(id),
	CONSTRAINT entry_subcategory_fk_category FOREIGN KEY (category_id) REFERENCES public.entry_category(id)
);

CREATE TABLE public.issuer (
	id int8 NOT NULL GENERATED ALWAYS AS IDENTITY( INCREMENT BY 1 MINVALUE 1 MAXVALUE 9223372036854775807 START 1 CACHE 1 NO CYCLE),
	user_id int8 NOT NULL,
	entry_subcategory_id int8 NOT NULL,
	description varchar(255) NOT NULL,
	created timestamp with time zone NOT NULL,,
	updated timestamp with time zone NOT NULL,,	
	CONSTRAINT issuer_pk PRIMARY KEY (id),
	CONSTRAINT issuer_fk_user FOREIGN KEY (user_id) REFERENCES public.user(id),
	CONSTRAINT issuer_fk_subcategory FOREIGN KEY (entry_subcategory_id) REFERENCES public.entry_subcategory(id)
);

CREATE TABLE public.entry (
	id int8 NOT NULL GENERATED ALWAYS AS IDENTITY( INCREMENT BY 1 MINVALUE 1 MAXVALUE 9223372036854775807 START 1 CACHE 1 NO CYCLE),
	user_id int8 NOT NULL,
	entry_type_id int2 NOT NULL,
	issuer_id int8 NOT NULL,
	value NUMERIC(12, 2) NOT NULL,	
	note varchar(4000) NULL,
	entry_date timestamp with time zone NOT NULL,,
	created timestamp with time zone NOT NULL,,
	updated timestamp with time zone NOT NULL,,
	active boolean NOT NULL,
	CONSTRAINT entry_pk PRIMARY KEY (id),
	CONSTRAINT entry_fk_user FOREIGN KEY (user_id) REFERENCES public.user(id),
	CONSTRAINT entry_fk_entry_type FOREIGN KEY (entry_type_id) REFERENCES public.entry_type(id)
);

CREATE TABLE public.balance (	
	user_id int8 NOT NULL,
	reference_month char(6) NOT NULL,
	balance NUMERIC(12, 2) NOT NULL,	
	created timestamp with time zone NOT NULL,,
	updated timestamp with time zone NOT NULL,,
	CONSTRAINT balance_pk PRIMARY KEY (user_id),
	CONSTRAINT balance_fk_user FOREIGN KEY (user_id) REFERENCES public.user(id)
);
COMMENT ON COLUMN public.balance.reference_month IS 'Information with format YYYYMM';





