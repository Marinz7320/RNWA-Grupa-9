const { GraphQLList } = require("graphql");
const { dbQuery } = require("../../database");
const LanguageType = require("../../types/LanguageType");

const fieldsLanguageTypes = {
  type: new GraphQLList(LanguageType),
  async resolve(_, {}) {
    let res = await dbQuery(`SELECT * FROM language`);
    return res;
  },
};

module.exports = fieldsLanguageTypes;
