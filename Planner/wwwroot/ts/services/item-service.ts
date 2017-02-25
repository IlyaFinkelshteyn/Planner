interface IItemService<TDetail> {
    patchItem: (id: number, patch: any) => angular.IHttpPromise<TDetail>;
}

interface ISubItemService<TCreate, TDetail> extends IItemService<TDetail> {
    deleteItem: (id: number) => angular.IHttpPromise<{}>;
    addItem: (eventId: number, item: TCreate) => angular.IHttpPromise<IdResult>;
}