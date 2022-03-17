import {
  Table,
  TableCell,
  TableHead,
  TablePagination,
  TableRow,
  TableSortLabel,
} from "@mui/material";
import { makeStyles } from "@mui/styles";
import React from "react";

const useStyles = makeStyles((theme) => ({
  table: {
    marginTop: theme.spacing(3),
    "& thead th": {
      fontWeight: "600",
      color: theme.palette.primary.main,
      backgroundColor: theme.palette.primary.light,
    },
    "& tbody td": {
      fontWeight: "300",
    },
    "& tbody tr:hover": {
      backgroundColor: "#FFFBF2",
      cursor: "pointer",
    },
  },
}));

export function useTable(headers, rows, filterFn) {
  const classes = useStyles();

  const TableContainer = (props) => {
    return <Table className={classes.table}>{props.children}</Table>;
  };

  const TableHeader = () => {
    const handleSort = (headerId) => {
      const isAsc = orderBy === headerId && order === "asc";
      setOrder(isAsc ? "desc" : "asc");
      setOrderBy(headerId);
    };

    return (
      <TableHead>
        <TableRow>
          {headers.map((header) => (
            <TableCell
              key={header.id}
              sortDirection={orderBy === header.id ? order : false}
            >
              {header.disableSorting ? (
                header.label
              ) : (
                <TableSortLabel
                  active={orderBy === header.id}
                  direction={orderBy === header.id ? order : "asc"}
                  onClick={() => handleSort(header.id)}
                >
                  {header.label}
                </TableSortLabel>
              )}
            </TableCell>
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

  //#region SORTING
  const [order, setOrder] = React.useState();
  const [orderBy, setOrderBy] = React.useState();

  const stableSort = (array, comparator) => {
    const stabilizedThis = array.map((element, index) => [element, index]);
    stabilizedThis.sort((a, b) => {
      const order = comparator(a[0], b[0]);
      if (order !== 0) {
        return order;
      }
      return a[1] - b[1];
    });
    return stabilizedThis.map((element) => element[0]);
  };

  const getComparator = (order, orderBy) => {
    return order === "desc"
      ? (a, b) => descendingComparator(a, b, orderBy)
      : (a, b) => descendingComparator(a, b, orderBy);
  };

  const descendingComparator = (a, b, orderBy) => {
    if (b[orderBy] < a[orderBy]) {
      return -1;
    }
    if (a[orderBy] > b[orderBy]) {
      return 1;
    }
    return 0;
  };
  //#endregion

  const rowsAfterPagingAndSorting = () => {
    return stableSort(filterFn.fn(rows), getComparator(order, orderBy)).slice(
      page * rowsPerPage,
      (page + 1) * rowsPerPage
    );
  };

  return {
    TableContainer,
    TableHeader,
    TablePaginator,
    rowsAfterPagingAndSorting,
  };
}
