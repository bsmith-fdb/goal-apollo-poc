DROP TABLE IF EXISTS IPT_BASIC_COLOR_A;

CREATE TABLE public.ipt_basic_color_a (
	id numeric(8) NOT NULL,
	wip_status_id numeric(8) NOT NULL,
	aud_create_date timestamp NOT NULL,
	aud_create_user_id numeric(8) NOT NULL,
	aud_checkout_date timestamp NULL,
	aud_checkout_user_id numeric(8) NULL,
	aud_last_modify_date timestamp NOT NULL,
	aud_last_modify_user_id numeric(8) NOT NULL,
	aud_publish_date timestamp NULL,
	aud_publish_user_id numeric(8) NULL,
	first_delivered_date timestamp NULL,
	last_delivered_date timestamp NULL,
	prev_delivered_date timestamp NULL,
	CONSTRAINT ipt_basic_color_a_pk PRIMARY KEY (id)
);

-- Permissions

ALTER TABLE public.ipt_basic_color_a OWNER TO magellan;
GRANT ALL ON TABLE public.ipt_basic_color_a TO magellan;