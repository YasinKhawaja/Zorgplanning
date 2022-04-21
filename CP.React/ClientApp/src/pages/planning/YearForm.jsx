import Grid from "@mui/material/Grid";
import Typography from "@mui/material/Typography";
import * as React from "react";
import Controls from "../../components/controls/Controls";

function YearForm(props) {
  const { options, form } = props;

  return (
    <React.Fragment>
      <Typography variant="h6" gutterBottom>
        Kies Jaar
      </Typography>
      <Grid container spacing={3}>
        <Grid item xs={12}>
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
        </Grid>
      </Grid>
    </React.Fragment>
  );
}

export default YearForm;
