import {
  FormControl,
  FormControlLabel,
  FormLabel,
  Radio,
  RadioGroup as MuiRadioGroup,
} from "@mui/material";
import React from "react";

export default function RadioGroup(props) {
  const { items, label, name, onChange, value } = props;
  return (
    <FormControl>
      <FormLabel>{label}</FormLabel>
      <MuiRadioGroup name={name} onChange={onChange} row value={value}>
        {items.map((item, index) => (
          <FormControlLabel
            control={<Radio />}
            key={index}
            label={item.title}
            value={item.id}
          ></FormControlLabel>
        ))}
      </MuiRadioGroup>
    </FormControl>
  );
}
