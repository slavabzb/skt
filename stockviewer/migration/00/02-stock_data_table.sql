create table STOCK_DATA(
	`stock_id` integer,
	`date` text not null,
	`open` real not null,
	`high` real not null,
	`low` real not null,
	`close` real not null,
	`volume` integer not null,
	unique (`stock_id`, `date`)
);
