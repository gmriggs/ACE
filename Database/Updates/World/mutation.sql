drop table if exists mutation_effect_argument;
drop table if exists mutation_effect;
drop table if exists mutation_effect_list;
drop table if exists mutation_outcome;
drop table if exists mutation_chance;
drop table if exists mutation;

drop table if exists mutation;

create table mutation
(
	id int unsigned not null auto_increment,
	mutation_Id int unsigned not null,
	idx int unsigned not null,
	primary key(id),
	index(mutation_Id)
);

drop table if exists mutation_chance;

create table mutation_chance
(
	id int unsigned not null auto_increment,
	mutation_Id int unsigned not null,
	chance double not null,
	primary key(id),
	index(mutation_Id),
	constraint mutation_chance_mutation_id foreign key (mutation_Id) references mutation (id) on delete cascade
);

drop table if exists mutation_outcome;

create table mutation_outcome
(
	id int unsigned not null auto_increment,
	mutation_Id int unsigned not null,
	primary key(id),
	index(mutation_Id),
	constraint mutation_outcome_mutation_id foreign key (mutation_Id) references mutation (id) on delete cascade
);

drop table if exists mutation_effect_list;

create table mutation_effect_list
(
	id int unsigned not null auto_increment,
	mutation_Outcome_Id int unsigned not null,
	idx int unsigned not null,
	probability double not null,
	primary key(id),
	index(mutation_Outcome_Id),
	constraint mutation_effect_list_mutation_outcome_id foreign key (mutation_Outcome_Id) references mutation_outcome (id) on delete cascade
);

drop table if exists mutation_effect;

create table mutation_effect
(
	id int unsigned not null auto_increment,
	mutation_Effect_List_Id int unsigned not null,
	effect_Type int unsigned not null,
	primary key(id),
	index(mutation_Effect_List_Id),
	constraint mutation_effect_mutation_effect_list_id foreign key (mutation_Effect_List_Id) references mutation_effect_list (id) on delete cascade
);

drop table if exists mutation_effect_argument;

create table mutation_effect_argument
(
	id int unsigned not null auto_increment,
	mutation_Effect_Id int unsigned not null,
	arg_Type int unsigned not null,
	effect_Type int unsigned,
	double_Val double,
	int_Val int,
	stat_Type int,
	stat_Idx int,
	min_Val float,
	max_Val float,
	primary key(id),
	constraint mutation_effect_argument_mutation_effect_id foreign key (mutation_Effect_Id) references mutation_effect (id) on delete cascade
);