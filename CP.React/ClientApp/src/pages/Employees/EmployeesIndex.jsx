import PeopleAltIcon from "@mui/icons-material/PeopleAlt";
import { Paper } from "@mui/material";
import { makeStyles } from "@mui/styles";
import Header from "../../components/Header";
import PageHeader from "../../components/PageHeader";
import Employees from "./Employees";

const useStyles = makeStyles((theme) => ({
  pageContent: { margin: theme.spacing(5), padding: theme.spacing(3) },
}));

export default function EmployeesIndex() {
  const classes = useStyles();
  return (
    <>
      <Header />
      <PageHeader
        icon={<PeopleAltIcon fontSize="large" />}
        title="Employees"
        subtitle="All Employees in Team x"
      />
      <Paper className={classes.pageContent}>
        <Employees />
      </Paper>
    </>
  );
}
