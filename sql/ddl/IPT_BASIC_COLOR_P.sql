-- public.ipt_basic_color_p definition

-- Drop table

-- DROP TABLE public.ipt_basic_color_p;

CREATE TABLE public.ipt_basic_color_p (
	id bigint NOT NULL,
	description varchar(30) NOT NULL,
	abbreviation varchar(7) NOT NULL,
	short_abbreviation varchar(4) NOT NULL,
	do_not_use_ind bpchar(1) NOT NULL,
	CONSTRAINT ipt_basic_color_p_ck1 CHECK ((do_not_use_ind = ANY (ARRAY['0'::bpchar, '1'::bpchar]))),
	CONSTRAINT ipt_basic_color_p_pk PRIMARY KEY (id)
);

-- Permissions

ALTER TABLE public.ipt_basic_color_p OWNER TO magellan;
GRANT ALL ON TABLE public.ipt_basic_color_p TO magellan;


-- public.ipt_basic_color_p foreign keys

ALTER TABLE public.ipt_basic_color_p ADD CONSTRAINT ipt_basic_color_p_fk1 FOREIGN KEY (id) REFERENCES public.ipt_basic_color_a(id);