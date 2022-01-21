do $$
DECLARE 
color_id ipt_color_a.id%TYPE;
basic_color_id ipt_basic_color_a.id%TYPE;
BEGIN

	ALTER TABLE ipt_color_a
	ALTER COLUMN id
	DROP IDENTITY IF EXISTS;

	alter table ipt_color_a
	alter column id
	add generated always as identity;

	perform setval(
		pg_get_serial_sequence('ipt_color_a', 'id'),
		(select max(id) from ipt_color_a)
	);
	


	ALTER TABLE ipt_basic_color_a
	ALTER COLUMN id
	DROP IDENTITY IF EXISTS;

	alter table ipt_basic_color_a
	alter column id
	add generated always as identity;

	perform setval(
		pg_get_serial_sequence('ipt_basic_color_a', 'id'),
		(select max(id) from ipt_basic_color_a)
	);

end $$;


