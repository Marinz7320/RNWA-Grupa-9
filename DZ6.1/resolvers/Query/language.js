const { GraphQLInt } = require("graphql");
const { dbQuery } = require("../../database");
const LanguageType = require("../../types/Language");

const fieldsLanguageType = {
  type: LanguageType,
  args: {
    language_id: { type: GraphQLInt },
  },
  async resolve(_, { language_id }) {
    let res = await dbQuery(
      `SELECT * FROM language WHERE language_id = ${language_id}`
    );
    return res[0];
  },
};

module.exports = fieldsLanguageType;
