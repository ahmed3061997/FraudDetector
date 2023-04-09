class AgGridUtils {

    static ensureNumberCell(params) {
        var cellClass = params.colDef.cellClass;
        if (cellClass?.includes('number-cell')) {
            $('.ag-text-field-input').attr('type', 'number');
        }
    }

    static validateGrid(gridOptions) {
        return true;
    }
}