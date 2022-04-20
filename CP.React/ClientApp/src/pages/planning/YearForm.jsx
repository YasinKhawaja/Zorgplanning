import Grid from "@mui/material/Grid";
import Typography from "@mui/material/Typography";
import * as React from "react";
import Controls from "../../components/controls/Controls";
import { useForm } from "../../hooks/useForm";
import { getYearsForSelectInput } from "./planning-utils";

const initialValues = { year: "0" };

function YearForm() {
  const [options, setOptions] = React.useState([]);

  React.useEffect(() => {
    const years = getYearsForSelectInput(new Date().getFullYear());
    setOptions(years);
  }, []);

  const form = useForm(initialValues);

  return (
    <React.Fragment>
      <Typography variant="h6" gutterBottom>
        Kies Jaar
      </Typography>
      <form>
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
      </form>
    </React.Fragment>
  );
}

export default YearForm;
