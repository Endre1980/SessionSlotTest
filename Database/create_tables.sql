  -- session_slots --
  CREATE SEQUENCE test.session_slots_id_seq;
  CREATE TABLE test.session_slots (
                  id                  INTEGER NOT NULL DEFAULT nextval('test.session_slots_id_seq'),
                  user_id             INTEGER NOT NULL,
                  guid                VARCHAR NOT NULL,
                  login_at_utc        TIMESTAMP NOT NULL,
                  last_active_at_utc  TIMESTAMP NOT NULL,
                  application_name    VARCHAR NOT NULL,
                  last_browser_active_at_utc TIMESTAMP NOT NULL DEFAULT now(),
                  CONSTRAINT pk_session_slots_id PRIMARY KEY (id)
  );
  ALTER SEQUENCE test.session_slots_id_seq OWNED BY test.session_slots.id;

  CREATE UNIQUE INDEX ix_session_slots_guid ON test.session_slots (guid);
  ALTER TABLE test.session_slots	ADD CONSTRAINT un_session_slots__guid UNIQUE (guid);
  
  -- session_slot_data --
	CREATE SEQUENCE test.session_slot_data_id_seq;
	CREATE TABLE test.session_slot_data (
		id                  INTEGER		NOT NULL DEFAULT nextval('test.session_slot_data_id_seq'),
		session_slot_guid   VARCHAR		NOT NULL,
		key                 VARCHAR		NOT NULL,
		data                BYTEA		NOT NULL,
		modified_at_utc		  TIMESTAMP	NOT NULL,
		CONSTRAINT pk_session_slot_data_id PRIMARY KEY (id)
	);
	ALTER SEQUENCE test.session_slot_data_id_seq OWNED BY test.session_slot_data.id;
	
	ALTER TABLE test.session_slot_data ADD CONSTRAINT fk_session_slot_data_session_slot_guid__
		FOREIGN KEY (session_slot_guid)
		REFERENCES test.session_slots (guid)
		ON DELETE CASCADE
		ON UPDATE NO ACTION
		NOT DEFERRABLE;
   
	ALTER TABLE test.session_slot_data ADD CONSTRAINT un_session_slot_data__session_slot_guid_key UNIQUE (session_slot_guid,key);