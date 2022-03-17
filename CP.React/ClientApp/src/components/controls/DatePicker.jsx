import DateFnsUtils from "@date-io/date-fns";
import {
  KeyboardDatePicker,
  MuiPickersUtilsProvider,
} from "@material-ui/pickers";
import React from "react";

export default function DatePicker(props) {
  const { label, name, onChange, value } = props;

  const convertToDefaultEventParameter = (name, value) => ({
    target: {
      name,
      value,
    },
  });

  return (
    <MuiPickersUtilsProvider utils={DateFnsUtils}>
      <KeyboardDatePicker
        disableToolbar
        format="dd/MM/yyyy"
        inputVariant="outlined"
        label={label}
        name={name}
        onChange={(date) => {
          onChange(convertToDefaultEventParameter(name, date));
        }}
        value={value}
        variant="inline"
      />
    </MuiPickersUtilsProvider>
  );
}
