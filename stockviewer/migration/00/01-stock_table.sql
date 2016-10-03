create table STOCK(
	`stock_id` integer primary key,
	`name` text not null,
	unique (`stock_id`, `name`)
);
