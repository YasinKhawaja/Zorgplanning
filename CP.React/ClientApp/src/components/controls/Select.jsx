import {
  FormControl,
  FormHelperText,
  InputLabel,
  MenuItem,
  Select as MuiSelect,
} from "@mui/material";
import React from "react";

function Select(props) {
  const {
    fullWidth = false,
    error = null,
    label,
    name,
    onChange,
    options,
    required = false,
    value,
    variant = "outlined",
  } = props;

  return (
    <FormControl
      fullWidth={fullWidth}
      required={required}
      variant={variant}
      {...(error && { error: true })}
    >
      <InputLabel>{label}</InputLabel>
      <MuiSelect label={label} name={name} onChange={onChange} value={value}>
        <MenuItem value="">None</MenuItem>
        {options.map((option) => (
          <MenuItem key={option.id} value={option.id}>
            {option.name}
          </MenuItem>
        ))}
      </MuiSelect>
      {error && <FormHelperText>{error}</FormHelperText>}
    </FormControl>
  );
}

export default Select;
