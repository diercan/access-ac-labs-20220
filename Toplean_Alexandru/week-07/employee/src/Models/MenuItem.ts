export type MenuItem = {
  id?: number;
  menuID?: number;
  name: string;
  ingredients: string;
  alergens?: string;
  price: number;
  image?: Uint8Array;
  imageURL?: string;
};
