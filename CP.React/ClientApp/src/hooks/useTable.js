import {
  Table,
  TableCell,
  TableHead,
  TablePagination,
  TableRow,
} from "@mui/material";
import { makeStyles } from "@mui/styles";
import React from "react";

const useStyles = makeStyles((theme) => ({
  table: {
    marginTop: theme.spacing(3),
    "& thead th": {
      backgroundColor: theme.palette.primary.light,
      color: theme.palette.primary.main,
      fontWeight: "600",
      textAlign: "center",
    },
    "& tbody td": {
      fontWeight: "300",
      textAlign: "center",
    },
    "& tbody tr:hover": {
      backgroundColor: "#FFFBF2",
      cursor: "pointer",
    },
  },
}));

export function useTable(headers, rows) {
  const classes = useStyles();

  const TableContainer = (props) => {
    return <Table className={classes.table}>{props.children}</Table>;
  };

  const TableHeader = () => {
    return (
      <TableHead>
        <TableRow>
          {headers.map((header) => (
            <TableCell key={header.id}>{header.label}</TableCell>
          ))}
        </TableRow>
      </TableHead>
    );
  };

  //#region PAGINATION
  const pages = [5, 10, 25];
  const [page, setPage] = React.useState(0);
  const [rowsPerPage, setRowsPerPage] = React.useState(pages[page]);

  const handlePageChange = (event, newPage) => {
    setPage(newPage);
  };

  const handleRowsPerPageChange = (event) => {
    setRowsPerPage(parseInt(event.target.value, 10));
    setPage(0);
  };

  const TablePaginator = () => (
    <TablePagination
      component="div"
      count={rows.length}
      page={page}
      rowsPerPage={rowsPerPage}
      rowsPerPageOptions={pages}
      onPageChange={handlePageChange}
      onRowsPerPageChange={handleRowsPerPageChange}
    ></TablePagination>
  );
  //#endregion

  return {
    TableContainer,
    TableHeader,
    TablePaginator,
  };
}
