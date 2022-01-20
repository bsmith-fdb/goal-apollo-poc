DROP TABLE IF EXISTS IPT_COLOR_H;

CREATE TABLE public.ipt_color_h (
	id numeric(8) NOT NULL,
	rev_nbr numeric(4) NOT NULL,
	change_user_id numeric(8) NOT NULL,
	change_timestamp timestamp NOT NULL,
	change_type bpchar(1) NOT NULL,
	dcr_nbr numeric(5) NULL,
	legacy_change_user varchar(9) NULL,
	CONSTRAINT ipt_color_h_ck1 CHECK ((change_type = ANY (ARRAY['A'::bpchar, 'C'::bpchar, 'D'::bpchar, 'P'::bpchar, 'R'::bpchar]))),
	CONSTRAINT ipt_color_h_pk PRIMARY KEY (id, rev_nbr)
);

-- Permissions

ALTER TABLE public.ipt_color_h OWNER TO magellan;
GRANT ALL ON TABLE public.ipt_color_h TO magellan;