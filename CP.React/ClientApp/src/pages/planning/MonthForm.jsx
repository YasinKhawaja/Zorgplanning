import * as React from "react";
import Controls from "../../components/controls/Controls";

export default function MonthForm(props) {
  const { options, form } = props;

  return (
    <Controls.Select
      fullWidth
      label="Maand"
      name="month"
      onChange={form.handleInputChange}
      options={options}
      required
      value={form.values.month}
      variant="standard"
    />
  );
}
