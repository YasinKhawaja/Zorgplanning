import { Skeleton } from "@mui/material";
import * as React from "react";
import Controls from "../../components/controls/Controls";

export default function TeamForm(props) {
  const { options, form } = props;

  return (
    <>
      {options.length === 0 ? (
        <Skeleton animation="wave" />
      ) : (
        <Controls.Select
          fullWidth
          label="Team"
          name="teamId"
          onChange={form.handleInputChange}
          options={options}
          required
          value={form.values.teamId}
          variant="standard"
        />
      )}
    </>
  );
}
