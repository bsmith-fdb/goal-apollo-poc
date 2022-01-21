-- public.ipt_color_w definition

-- Drop table

-- DROP TABLE public.ipt_color_w;

CREATE TABLE public.ipt_color_w (
	id bigint NOT NULL,
	description varchar(30) NOT NULL,
	basic_color_id bigint NOT NULL,
	abbreviation varchar(15) NOT NULL,
	do_not_use_ind bpchar(1) NOT NULL,
	CONSTRAINT ipt_color_w_ck1 CHECK ((do_not_use_ind = ANY (ARRAY['0'::bpchar, '1'::bpchar]))),
	CONSTRAINT ipt_color_w_pk PRIMARY KEY (id)
);

-- Permissions

ALTER TABLE public.ipt_color_w OWNER TO magellan;
GRANT ALL ON TABLE public.ipt_color_w TO magellan;


-- public.ipt_color_w foreign keys

ALTER TABLE public.ipt_color_w ADD CONSTRAINT ipt_color_w_fk1 FOREIGN KEY (id) REFERENCES public.ipt_color_a(id);
ALTER TABLE public.ipt_color_w ADD CONSTRAINT ipt_color_w_fk2 FOREIGN KEY (basic_color_id) REFERENCES public.ipt_basic_color_w(id);