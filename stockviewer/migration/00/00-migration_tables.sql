create table MIGRATION_VERSION(
	`version` integer not null,
	`dirty` integer not null
);

insert into MIGRATION_VERSION values (0, 0);

create table MIGRATION_FILES(
	`file` text not null
);
