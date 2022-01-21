-- public.ipt_basic_color_h definition

-- Drop table

-- DROP TABLE public.ipt_basic_color_h;

CREATE TABLE public.ipt_basic_color_h (
	id bigint NOT NULL,
	rev_nbr int NOT NULL,
	change_user_id bigint NOT NULL,
	change_timestamp timestamptz NOT NULL,
	change_type bpchar(1) NOT NULL,
	dcr_nbr int NULL,
	legacy_change_user varchar(9) NULL,
	CONSTRAINT ipt_basic_color_h_ck1 CHECK ((change_type = ANY (ARRAY['A'::bpchar, 'C'::bpchar, 'D'::bpchar, 'P'::bpchar, 'R'::bpchar]))),
	CONSTRAINT ipt_basic_color_h_pk PRIMARY KEY (id, rev_nbr)
);

-- Permissions

ALTER TABLE public.ipt_basic_color_h OWNER TO magellan;
GRANT ALL ON TABLE public.ipt_basic_color_h TO magellan;