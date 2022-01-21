-- public.ipt_basic_color_a definition

-- Drop table

-- DROP TABLE public.ipt_basic_color_a;

CREATE TABLE public.ipt_basic_color_a (
	id bigint NOT NULL,
	wip_status_id bigint NOT NULL,
	aud_create_date timestamptz NOT NULL,
	aud_create_user_id bigint NOT NULL,
	aud_checkout_date timestamptz NULL,
	aud_checkout_user_id bigint NULL,
	aud_last_modify_date timestamptz NOT NULL,
	aud_last_modify_user_id bigint NOT NULL,
	aud_publish_date timestamptz NULL,
	aud_publish_user_id bigint NULL,
	first_delivered_date timestamptz NULL,
	last_delivered_date timestamptz NULL,
	prev_delivered_date timestamptz NULL,
	CONSTRAINT ipt_basic_color_a_pk PRIMARY KEY (id)
);

-- Permissions

ALTER TABLE public.ipt_basic_color_a OWNER TO magellan;
GRANT ALL ON TABLE public.ipt_basic_color_a TO magellan;