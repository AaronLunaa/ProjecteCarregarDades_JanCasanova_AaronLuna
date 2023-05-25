CREATE TRIGGER insert_actors_trigger AFTER INSERT ON movies
FOR EACH ROW
BEGIN
  -- Insereix un nom predeterminat a actors de la nova pel·lícula cuan es fa un insert a la taula actors
  INSERT INTO actors (movie_id, name, role)
  VALUES (NEW.id, 'Actor 1', 'Role 1'), (NEW.id, 'Actor 2', 'Role 2');
  
END;
