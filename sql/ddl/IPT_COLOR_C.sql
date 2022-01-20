DROP TABLE IF EXISTS IPT_COLOR_C;


CREATE TABLE public.ipt_color_c (
	id numeric(8) NOT NULL,
	rev_nbr numeric(4) NOT NULL,
	description varchar(30) NOT NULL,
	basic_color_id numeric(8) NOT NULL,
	abbreviation varchar(15) NULL,
	do_not_use_ind bpchar(1) NOT NULL,
	change_type bpchar(1) NOT NULL,
	change_user_id numeric(8) NOT NULL,
	change_timestamp timestamp NOT NULL,
	concept_rev_nbr numeric(4) NOT NULL,
	dcr_nbr numeric(5) NULL,
	legacy_change_user varchar(9) NULL,
	CONSTRAINT ipt_color_c_ck1 CHECK ((do_not_use_ind = ANY (ARRAY['0'::bpchar, '1'::bpchar]))),
	CONSTRAINT ipt_color_c_ck2 CHECK ((change_type = ANY (ARRAY['A'::bpchar, 'C'::bpchar, 'D'::bpchar, 'P'::bpchar, 'R'::bpchar]))),
	CONSTRAINT ipt_color_c_pk PRIMARY KEY (id, rev_nbr)
);

-- Permissions

ALTER TABLE public.ipt_color_c OWNER TO magellan;
GRANT ALL ON TABLE public.ipt_color_c TO magellan;