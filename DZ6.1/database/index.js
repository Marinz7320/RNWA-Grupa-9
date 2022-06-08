const mysql = require("mysql");
const util = require("util");

const conn = mysql.createConnection({
  host: localhost,
  user: root,
  database: movies,
  port: 3307,
  charset: "utf8mb4",
  dateStrings: true,
});

const dbQuery = util.promisify(conn.query).bind(conn);

module.exports = { dbQuery };
