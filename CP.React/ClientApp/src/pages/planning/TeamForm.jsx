import { Skeleton } from "@mui/material";
import Grid from "@mui/material/Grid";
import Typography from "@mui/material/Typography";
import * as React from "react";
import Controls from "../../components/controls/Controls";

export default function TeamForm(props) {
  const { options, form } = props;

  const selectInput =
    options.length === 0 ? (
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
    );

  return (
    <React.Fragment>
      <Typography variant="h6" gutterBottom>
        Kies Team
      </Typography>
      <Grid container spacing={3}>
        <Grid item xs={12}>
          {selectInput}
        </Grid>
      </Grid>
    </React.Fragment>
  );
}
