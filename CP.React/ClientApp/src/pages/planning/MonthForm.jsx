import Grid from "@mui/material/Grid";
import Typography from "@mui/material/Typography";
import * as React from "react";
import Controls from "../../components/controls/Controls";

function MonthForm(props) {
  const { options, form } = props;

  return (
    <React.Fragment>
      <Typography variant="h6" gutterBottom>
        Kies Maand
      </Typography>
      <Grid container spacing={3}>
        <Grid item xs={12}>
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
        </Grid>
      </Grid>
    </React.Fragment>
  );
}

export default MonthForm;
