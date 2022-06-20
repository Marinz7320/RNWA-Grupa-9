const express = require("express");
const app = express();
const bodyParser = require("body-parser");
const mysql = require("mysql");
const cors = require("cors");

app.use(bodyParser.json());
app.use(
  bodyParser.urlencoded({
    extended: true,
  })
);
app.use(cors());

app.get("/", function (req, res) {
  return res.send({ error: true, message: "hello" });
});

const dbConn = mysql.createConnection({
  host: "localhost",
  port: 3307,
  user: "root",
  database: "movies",
});

dbConn.connect((err) => err && console.log(err));

app.get("/movies", function (req, res) {
  dbConn.query("SELECT * FROM country", function (error, results, fields) {
    if (error) throw error;
    return res.send({
      error: false,
      data: results,
      message: "Lista drzava",
    });
  });
});

app.get("/movies/:id", function (req, res) {
  let id = req.params.id;
  if (!id) {
    return res.status(400).send({ error: true, message: "Please provide id" });
  }

  dbConn.query(
    "SELECT * FROM movie where movie_id=?",
    id,
    function (error, results, fields) {
      if (error) throw error;
      return res.send({
        error: false,
        data: results.length > 0 ? results[0] : null,
      });
    }
  );
});

app.post("/movies", function (req, res) {
  let database = req.body.database;
  const { naziv, opis } = database;

  if (!database) {
    return res
      .status(400)
      .send({ error: true, message: "Morate dati bazu podataka" });
  }

  dbConn.query(
    "INSERT INTO department VALUES(NULL, ?)",
    [department_name],
    function (error, results, fields) {
      if (error) throw error;
      return res.send({
        error: false,
        data: results,
        message: "Insertano novo odijeljenje.",
      });
    }
  );
});

app.put("/movies", function (req, res) {
  let database = req.body.employee;
  const { id, department_name } = database;

  if (!id || !database) {
    return res.status(400).send({
      error: true,
      employee,
      message: "Please provide value for database and id",
    });
  }

  dbConn.query(
    "UPDATE department SET department_name = ? where department_id = ?",
    [department_name, department_id],
    function (error, results, fields) {
      if (error) throw error;
      return res.send({
        error: false,
        data: results,
        message: "Database has been updated successfully.",
      });
    }
  );
});

app.delete("/movies/:id", function (req, res) {
  let id = req.params.id;
  if (!id) {
    return res.status(400).send({
      error: true,
      message: "Please provide value for id",
    });
  }

  dbConn.query(
    "DELETE FROM department where department_id = ?",
    [id],
    function (error, results, fields) {
      if (error) throw error;
      return res.send({
        error: false,
        data: results,
        message: "Ažuriran naziv odijeljenja.",
      });
    }
  );
});

app.listen(3000, function () {
  console.log("Node app is running on port 3000");
});
module.exports = app;
