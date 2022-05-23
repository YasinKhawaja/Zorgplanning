import * as React from "react";
import Controls from "../../components/controls/Controls";

export default function YearForm(props) {
  const { options, form } = props;

  return (
    <Controls.Select
      fullWidth
      label="Jaar"
      name="year"
      onChange={form.handleInputChange}
      options={options}
      required
      value={form.values.year}
      variant="standard"
    />
  );
}
