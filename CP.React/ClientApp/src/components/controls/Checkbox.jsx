import {
  Checkbox as MuiCheckbox,
  FormControl,
  FormControlLabel,
} from "@mui/material";
import React from "react";

export default function Checkbox(props) {
  const { label, name, onChange, value } = props;

  const convertToDefaultEventParameter = (name, value) => ({
    target: {
      name,
      value,
    },
  });

  return (
    <FormControl>
      <FormControlLabel
        control={
          <MuiCheckbox
            checked={value}
            color="primary"
            onChange={(event) =>
              onChange(
                convertToDefaultEventParameter(name, event.target.checked)
              )
            }
            name={name}
          />
        }
        label={label}
      ></FormControlLabel>
    </FormControl>
  );
}
